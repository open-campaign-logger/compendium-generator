# ChatGPT Module
The ChatGPT module facilitates the creationg of compendiums using OpenAI's ChatGPT service.  All subsequent markdown text will be copied directly into the resulting Campaign Entry.

## Basic Configuration

## Additional Configuration
You need to add the following value to user secrets for the `CampaignKit.Compendium.Tests` test project to work.  (Right click `CampaignKit.Compendium.Tests` select `Manage User Secrets`)
```json
{
  "Services": [
    {
      "Name": "ChatGPT 4",
      "Endpoint": "",
      "APIKey": "YOUR KEY HERE",
      "IsActive": true
    }
  ]
}
```