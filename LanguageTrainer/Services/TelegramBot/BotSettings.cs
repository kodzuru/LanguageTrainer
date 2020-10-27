namespace LanguageTrainer.Services.TelegramBot
{
    public static class BotSettings
    {
        public static string ApiKey { get; } = "1377960596:AAHhh78N6ibfO4pxGMz8Gcb1qNILFV9BnIw";
        public static string Url { get; } = "https://a289575ddf32.ngrok.io/{0}";
        public static string BotName { get; } = "PetuchAliveBot";
        public static string Start { get; } = "start";



        public static class KeyboardCommands
        {
            public static string SetWordsGettingState { get; set; } = "😀 GetWordsState";
        }
        public static class InlineCommands
        {

        }
    }
}
