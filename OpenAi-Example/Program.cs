using Azure;
using Azure.AI.OpenAI;
using OpenAI.Chat;

var endpoint = new Uri("https://openai-service-rtotechlabs.openai.azure.com/");
var model = "gpt-4o-mini";
var deploymentName = "gpt-4o-mini-example";
var apiKey = "miclave";

AzureOpenAIClient azureClient = new(
    endpoint,
    new AzureKeyCredential(apiKey));
ChatClient chatClient = azureClient.GetChatClient(deploymentName);


Console.WriteLine("Bienvenidos al mundo inteligente");
string mensajeUno = "Hola, soy tu asistente de Azure OpenAI. ¿Cómo puedo ayudarte hoy?";
Console.WriteLine(mensajeUno);

string receptor = Console.ReadLine();

List<ChatMessage> messages = new List<ChatMessage>()
{
    new SystemChatMessage(mensajeUno),
    new UserChatMessage(receptor),
};

var response = chatClient.CompleteChat(messages);
Console.WriteLine(response.Value.Content[0].Text);

messages.Add(new AssistantChatMessage(response.Value.Content[0].Text));
Console.WriteLine("Escribe un mensaje para continuar la conversación:");
string mensajito = Console.ReadLine();
messages.Add(new UserChatMessage(mensajito));

response = chatClient.CompleteChat(messages);
Console.WriteLine(response.Value.Content[0].Text); 
Console.ReadLine();