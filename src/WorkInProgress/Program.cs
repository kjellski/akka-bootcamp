using Akka.Actor;

namespace WinTail
{
	internal class Program
	{
		public static ActorSystem MyActorSystem;

		private static void Main()
		{
			// make an actor system 
			MyActorSystem = ActorSystem.Create("MyActorSystem");

			// set up actors, using props (split props onto own line so easier to read)
			var consoleWriterProps = Props.Create<ConsoleWriterActor>();
			var consoleWriterActor = MyActorSystem.ActorOf(consoleWriterProps, "consoleWriterActor");

			var tailCoordinatorActorProps = Props.Create<TailCoordinatorActor>();
			var tailCoordinatorActor = MyActorSystem.ActorOf(tailCoordinatorActorProps, "tailCoordinatorActor");
			
			var fileValidatorActorProps = Props.Create(() => new FileValidatorActor(consoleWriterActor, tailCoordinatorActor));
			var validationActor = MyActorSystem.ActorOf(fileValidatorActorProps, "validationActor");

			var consoleReaderProps = Props.Create<ConsoleReaderActor>(validationActor);
			var consoleReaderActor = MyActorSystem.ActorOf(consoleReaderProps, "consoleReaderActor");

			// tell console reader to begin
			consoleReaderActor.Tell(ConsoleReaderActor.StartCommand);

			// blocks the main thread from exiting until the actor system is shut down
			MyActorSystem.AwaitTermination();
		}
	}
}