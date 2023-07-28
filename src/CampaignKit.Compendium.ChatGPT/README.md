# ChatGPT Module
The ChatGPT module facilitates the creationg of compendiums using OpenAI's ChatGPT service.  All subsequent markdown text will be copied directly into the resulting Campaign Entry.

## Service Configuration
You need to add the following value to user secrets for the `CampaignKit.Compendium.Tests` test project to work.  (Right click `CampaignKit.Compendium.Tests` select `Manage User Secrets`)
```json
  "Services": [
    {
      // This will be your private OpenAI API key.  See: https://platform.openai.com/
      "APIKey": "...",
      // Activate/Inactivate the service.  Due to the cost-per-transaction nature of
      // the service this flag is provided to explicitly enable/disable access to the 
      // service so that charges aren't accrued unintentionally.
      "IsActive": true,
      // Name of the OpenAI data model to use.  Supported models are shown below.
      "Model": "gpt-4",
      // This must always be the value shown.
      "Name": "ChatGPT"
    }
  ]
```

## Prompt Configuration
A number of examples of how to configure the creation of compendiums using this module are included in the default application (`appsettings.json`) configuration. 

Here is an example of a prompt that will result in the creation of a compendium of rolltables for a Dungeons and Dragons 5e game.

```json
    {
      // The Dependency Injection service class for processing this compendium.
      "CompendiumService": "CampaignKit.Compendium.ChatGPT.Services.IChatGPTCompendiumService, CampaignKit.Compendium.ChatGPT.dll",
      // Description of the compendium.
      "Description": "Prompt generated entities from ChatGPT.",
      // Name of the game system.  This name will be used for organizing generated files.  Make sure it's a path safe string.  (avoid special characters)
      "GameSystem": "Dungeons and Dragons 5e",
      // Image to use for the compendium.
      "ImageUrl": "https://campaign-logger.com/images/campaign-logger.png",
      // List of prompts to provide to the chatbot for the purposes of text generation.
      "Prompts": [
        {
          // The genre that the generated response should pertain to.
          "Genre": "Fantasy",
          // A list of default labels to apply to all entries created from this prompt.
          "Labels": [
            "Rolltable",
            "Fumble",
            "D&D 5E",
            "Melee"
          ],
          // The name of the prompt. This will used for naming the campaign entry that's created from the prompt response.
          "Name": "Fumble Tables - Melee",
          // A value indicating whether new data should be downloaded to replace saved prompt responses.
          "OverwriteExisting": true,
          // The list of prompts to use for generating content.
          "PromptMessages": [
            {
              "Heading": "## Melee",
              "Message": "Generate a d100 ('d100' means percentile dice which can produce a value of 1 to 100)  rolltable in markdown format for the following:\nTopic: Mishaps due to a critical failure on a melee attack\nGenre: {Genre}\nGame System: {GameSystem}\nSentiment: {Sentiment}"
            }
          ],
          // The role that the service will play when generating content.
          "Role": "You are a game master who helps other game masters develop rolltables to help them run their games.  Responses should be limited to what was specifically asked for.  Do not include introduction or closing text.  All generated tables should be in markdown format.  Do not surround any markdown text with fenced code blocks.",
          // The sentiment to use for generating the response.
          // Value is an integer from 1 to 10.
          // A value of `1` means that responses should be entirely serious.
          // A value of `10` means that responses should be entirely whimsical.
          "Sentiment": 2,
          // Always set to this value.
          "Service": "ChatGPT",
          // The tag entry to use for campaign entries created from this prompt.
          "TagSymbol": "~"
        },
        {
          "Genre": "Fantasy",
          "Labels": [
            "Rolltable",
            "Names",
            "D&D 5E",
            "NPCs",
            "Dragon"
          ],
          "Name": "Dragon Names",
          "OverwriteExisting": true,
          "PromptMessages": [
            {
              "Heading": "## Dragon",
              "Message": "Generate a d100 ('d100' means percentile dice which can produce a value of 1 to 100)  rolltable in markdown format for the following:\nTopic: NPC names and descriptions\nRace: Dragon\nGenre: {Genre}\nGame System: {GameSystem}\nSentiment: {Sentiment}\nTable Structure: Table should have three columns: dice value, name, description."
            }
          ],
          "Role": "You are a game master who helps other game masters develop rolltables to help them run their games.  Responses should be limited to what was specifically asked for.  Do not include introduction or closing text.  All generated tables should be in markdown format.  Do not surround any markdown text with fenced code blocks.",
          "Sentiment": 2,
          "Service": "ChatGPT",
          "TagSymbol": "~"
        },
        ...
      ],
      // Compendium title.
      "Title": "5e Rolltables"
    }
```

## Supported Models

* `text-ada-001`
* `text-embedding-ada-002`
* `text-babbage-001`
* `gpt-3.5-turbo`
* `gpt-3.5-turbo-0301`
* `text-curie-001`
* `code-cushman-001`
* `code-davinci-002`
* `text-davinci-003` <- Default
* `gpt-4`
* `gpt-4-32k`
* `text-moderation-latest`
* `text-moderation-stable`
