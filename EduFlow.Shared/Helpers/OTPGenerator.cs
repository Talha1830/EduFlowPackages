namespace EduFlow.Shared.Helpers
{
    public class OTPGenerator
    {
        private static readonly Random random = new Random();

        public static byte Generate4DigitOTP()
        {
            return (byte)random.Next(1000, 10000); // Generates a random number between 1000 and 9999 inclusive
        }
    }
}
