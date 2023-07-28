# ChatGPT Module
The ChatGPT module facilitates the creationg of compendiums using OpenAI's ChatGPT service.  All subsequent markdown text will be copied directly into the resulting Campaign Entry.

## Basic Configuration

## Additional Configuration
You need to add the following value to user secrets for the `CampaignKit.Compendium.Tests` test project to work.  (Right click `CampaignKit.Compendium.Tests` select `Manage User Secrets`)
```json
  "Services": [
    {
      "APIKey": "...",
      "Endpoint": "",
      "IsActive": true,
      "Model": "gpt-4",
      "Name": "ChatGPT"
    }
  ]
```

## Supported Models
* "text-ada-001"
* "text-embedding-ada-002"
* "text-babbage-001"
* "gpt-3.5-turbo"
* "gpt-3.5-turbo-0301"
* "text-curie-001"
* "code-cushman-001"
* "code-davinci-002"
* "text-davinci-003" <- Default
* "gpt-4"
* "gpt-4-32k"
* "text-moderation-latest"
* "text-moderation-stable"
