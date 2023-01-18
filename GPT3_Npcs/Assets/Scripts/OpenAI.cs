using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;


//c�digo sacado de https://github.com/unitycoder/UnityOpenAIGPT3/blob/main/Assets/Scripts/Data/OpenAIData.cs
//ver video https://www.youtube.com/watch?v=ripsfVDPym0
namespace UnityLibrary
{
    public class OpenAI : MonoBehaviour
    {
        const string url = "https://api.openai.com/v1/completions";

        public string modelName = "text-davinci-003";

        public NPCDATA loadedNpc;

        public static OpenAI Instance;

        public string context;

       //public InputField inputPrompt;
        public TextMesh output;
        
       //public GameObject loadingIcon;

        string apiKey = null;
        bool isRunning = false;

        //Singleton
        void Awake() 
        {
            
            if (Instance == null)
            {
                Instance = this;
                loadedNpc = null;
            }
            else
            {
                throw (new System.Exception("Only one instance of OpenAI is allowed"));
            }
        }
        
        void Start()
        {
            LoadAPIKey();
        }

        public void Execute(string input)
        {
            if (isRunning)
            {
                Debug.LogError("Already running");
                return;
            }
            isRunning = true;
            //loadingIcon.SetActive(true);

            string finalPrompt = PreparePromt(input);

            // fill in request data
            RequestData requestData = new RequestData()
            {
                model = modelName,
                prompt = finalPrompt,
                temperature = loadedNpc.Temperature,
                max_tokens = loadedNpc.MaxTokens,
                top_p = loadedNpc.TopP,
                frequency_penalty = loadedNpc.FrequencyPenalty,
                presence_penalty = loadedNpc.PresencePenalty,
                stop = loadedNpc.StopSequences
            };

            string jsonData = JsonUtility.ToJson(requestData);

            byte[] postData = System.Text.Encoding.UTF8.GetBytes(jsonData);

            UnityWebRequest request = UnityWebRequest.Post(url, jsonData);
            request.uploadHandler = new UploadHandlerRaw(postData);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "Bearer " + apiKey);

            UnityWebRequestAsyncOperation async = request.SendWebRequest();

            async.completed += (op) =>
            {
                if (request.result == UnityWebRequest.Result.ConnectionError)
                {
                    Debug.LogError(request.error);
                }
                else
                {
                    Debug.Log(request.downloadHandler.text);
                    // parse the results to get values 
                    OpenAIAPI responseData = JsonUtility.FromJson<OpenAIAPI>(request.downloadHandler.text);
                    // sometimes contains 2 empty lines at start?
                    string generatedText = responseData.choices[0].text.TrimStart('\n').TrimStart('\n');

                    output.text = generatedText;
                    VoiceController.Instance.StartSpeaking(generatedText);
                }
                //loadingIcon.SetActive(false);
                isRunning = false;
            };

        } // execute

        void LoadAPIKey()
        {
            // TODO optionally use from env.variable

            // MODIFY path to API key if needed

            /*
            var keypath = Path.Combine(Application.streamingAssetsPath, "secretkey.txt");
            if (File.Exists(keypath) == false)
            {
                Debug.LogError("Apikey missing: " + keypath);
            }
               
            //Debug.Log("Load apikey: " + keypath);
            apiKey = File.ReadAllText(keypath).Trim();
            */
            apiKey = "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";
            Debug.Log("API key loaded, len= " + apiKey.Length);
        }

        string PreparePromt(string input)
        {
            string finalPrompt = loadedNpc.Description + "\n\n" + loadedNpc.Examples + "\n\n" + loadedNpc.PlayerName + ": " + input + "\n" + loadedNpc.CharacterName + ": ";
            return finalPrompt;
        }
    }
}