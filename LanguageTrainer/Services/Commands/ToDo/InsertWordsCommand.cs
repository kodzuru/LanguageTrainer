using AutoMapper;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using LanguageTrainer.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace LanguageTrainer.Services.Commands.ToDo
{
    public class InsertWordsCommand : CommandBase
    {
        public IRepositoryWrapper Repository { get; }
        public IMapper Mapper { get; }

        public InsertWordsCommand(CommandInfo info, IRepositoryWrapper repository, IMapper mapper) : base(info)
        {
            this.Mapper = mapper;
            this.Repository = repository;
        }
        public override async Task Execute(Message message, ITelegramBotClient client)
        {
            string text = message.Text.Trim();
            if (Uri.IsWellFormedUriString(text, UriKind.RelativeOrAbsolute))
            {
                string range = "A:A";

                var sc = new SheetCore();
                sc.DoStaff(text, range);

                int i = 0;
                string result = string.Empty;
                foreach (var item in sc.Output)
                {
                    result += $"{++i}: {item}\n";
                }
                await client.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                     text: result
                );
            }
        }
    }
    public class SheetCore
    {
        string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        string ApplicationName = "Google Sheets API .NET Quickstart";
        public SortedDictionary<int, string> Output { get; set; } = new SortedDictionary<int, string>();
        private SheetsService service;
        public SheetCore()
        {
            UserCredential credential;

            using (var stream = new FileStream(@"E:\engine\repos\LanguageTrainer\LanguageTrainer\Credentials\credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Sheets API service.
            service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }
        public void DoStaff(string link, string range)
        {


            Regex patternSpreadsheetID = new Regex(@"/spreadsheets/d/(?<SpreadsheetID>[a-zA-Z0-9-_]+)");
            Regex patternSheetID = new Regex(@"[#&]gid=(?<SheetID>[0-9]+)");


            Match match = patternSpreadsheetID.Match(link);
            string spreadsheetId = match.Groups["SpreadsheetID"].Value;


            SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get(spreadsheetId, range);

            ValueRange response = request.Execute();
            IList<IList<object>> values = response.Values;
            if (values != null && values.Count > 0)
            {
                for (int i = 0; i < values.Count; i++)
                {
                    foreach (var cell in values[i])
                    {
                        if (string.IsNullOrEmpty(cell.ToString()))
                            continue;
                        Output.Add(i, cell as string);
                    }
                }
            }
            else
            {
                Console.WriteLine("No data found.");
            }

        }
    }
}
