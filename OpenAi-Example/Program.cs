using Azure;
using Azure.AI.OpenAI;
using OpenAI.Chat;

var endpoint = new Uri("https://openai-service-rtotechlabs.openai.azure.com/");
var model = "gpt-4o-mini";
var deploymentName = "gpt-4o-mini-example";
var apiKey = "Mi key";

AzureOpenAIClient azureClient = new(
    endpoint,
    new AzureKeyCredential(apiKey));
ChatClient chatClient = azureClient.GetChatClient(deploymentName);


List<ChatMessage> messages = new List<ChatMessage>()
{
    new SystemChatMessage("Tu eres mi asistente."),
    new UserChatMessage("Qué me puedes decir sobre Azure Logic Apps a un nivel de conocimiento experto, para que se puede usar?"),
};

var response = chatClient.CompleteChat(messages);
Console.WriteLine(response.Value.Content[0].Text);

messages.Add(new AssistantChatMessage(response.Value.Content[0].Text));
messages.Add(new UserChatMessage("Se puede usar para interceptar llamadas desde un Gateway hacia los microservicios? es buena práctica?"));

response = chatClient.CompleteChat(messages);
Console.WriteLine(response.Value.Content[0].Text); 
Console.ReadLine();