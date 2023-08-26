# Web Scraper Module

This module downloads compendium web pages and converts them into a format that is importable into the Campaign Logger application.

If the source material is standard HTML this module should work fairly well.  There are some spots in the configuration that you can use to substitute values for sections that don't parse correctly.  

If the source material is non-standard HTML you may have to create a custom parser to handle the translation logic.  See the WOIN module for an example.

## Configuration

A number of examples of how to configure the creation of compendiums using this module are included in the default application (`module_webscraper.json`) configuration. 

```json
    {
      // The Dependency Injection service class for processing this compendium.
      "CompendiumService": "CampaignKit.Compendium.WebScraper.Services.IWebScraperCompendiumService, CampaignKit.Compendium.WebScraper.dll",
      // Description of the compendium
      "Description": "What's Old is new Again (WOIN) SRD material.'.",
      // Name of the game system.  This name will be used for organizing generated files.  Make sure it's a path safe string.  (avoid special characters)
      "GameSystem": "WOIN",
      // Image to use for the compendium.
      "ImageUrl": "https://campaign-logger.com/images/campaign-logger.png",
      // If true, process this compendium.  If not, skip it.
      "IsActive": true,
      // If true, overwrite an existing compendium if it already exists.  If false, and compendium exists, skip processing.
      "OverwriteExisting": true,
      // IMPORTANT: Each page must be configured as its own `SourceDataSet`.  
      "SourceDataSets": [
        {
          // Import limit is not currently supported for this module.
          // If you want to limit the number of items you'll have to reduce the JSON file size.
          // Default labels to apply to campaign entries derived from the source data.
          "Labels": [
            "WOIN",
            "Skill"
          ],
          // Name of the label that will be given to the campaign entry.
          // Notes:
          // 1. This label should be unique in the compendium.
          // 2. A local path is derived from the URL components for local storage of the webpage download.  
          //    In some cases you'll end up with name conflicts between folders (path) and files (the download)
          //    This is especially the case with subpages.  Example:
          //    - "https://www.woinrules.com/rules-of-the-game/skill-tasks"
          //      - Download to "./WOIN/rules-of-the-game/skill-tasks" where "skill-tasks" is a page.
          //    - "https://www.woinrules.com/rules-of-the-game/skill-tasks/engineering"
          //      - Download to "./WOIN/rules-of-the-game/skill-tasks/engineering" which fails because "skill-tasks" 
          //        has already been created as a page and can't be recreated as a folder.
          "SourceDataSetName": "Skill - Engineering",
          // Class to use for parsing source data information.
          "SourceDataSetParser": "CampaignKit.Compendium.WebScraper.Common.SRDWebPage, CampaignKit.Compendium.WebScraper.dll",
          // URI of source data set.
          "SourceDataSetURI": "https://www.woinrules.com/rules-of-the-game/skill-tasks/engineering",
          // A list of DOM subtitutions to perform before any other work is performed.
          // This is helpful for items that can't be easily converted to HTML.
          "Substitutions": [
            {
              // HTML to substitute at the specified location.
              "HTML": "<span><h2>Engineering Technobabble</h2><p>Roll d66 four times and read as &quot;alpha the beta gamma delta&#39; (e.g. “modify the quantum neutrino filter”).</p><table><thead><tr><th>d66</th><th>Alpha</th><th>Beta</th><th>Gamma</th><th>Delta</th></tr></thead><tbody><tr><td>11</td><td>increase</td><td>microscopic</td><td>quantum</td><td>relay</td></tr><tr><td>12</td><td>decrease</td><td>photonic</td><td>artificial</td><td>inversion</td></tr><tr><td>13</td><td>focus</td><td>linear</td><td>pulse</td><td>interference</td></tr><tr><td>14</td><td>amplify</td><td>sonic</td><td>flux</td><td>discriminator</td></tr><tr><td>15</td><td>reverse</td><td>auxiliary</td><td>gravimetric</td><td>signal</td></tr><tr><td>16</td><td>agitate</td><td>nucleonic</td><td>particle</td><td>capacitor</td></tr><tr><td>21</td><td>pacify</td><td>transwarp</td><td>system</td><td>configuration</td></tr><tr><td>22</td><td>invert</td><td>reciprocating</td><td>nadion</td><td>effect</td></tr><tr><td>23</td><td>boost</td><td>magnatomic</td><td>subspace</td><td>disturbance</td></tr><tr><td>24</td><td>nullify</td><td>quantum</td><td>frequency</td><td>field</td></tr><tr><td>25</td><td>energise</td><td>verteron</td><td>wavefront</td><td>phenomenon</td></tr><tr><td>26</td><td>intensify</td><td>ambient</td><td>spatial</td><td>array</td></tr><tr><td>31</td><td>electrify</td><td>anomalous</td><td>alternating</td><td>emission</td></tr><tr><td>32</td><td>eliminate</td><td>modulated</td><td>baryon</td><td>domain</td></tr><tr><td>33</td><td>oscillate</td><td>inverted</td><td>space-time</td><td>coupling</td></tr><tr><td>34</td><td>modulate</td><td>temporal</td><td>dampening</td><td>stream</td></tr><tr><td>35</td><td>monitor</td><td>asymmetrical</td><td>tetryon</td><td>variance</td></tr><tr><td>36</td><td>restrict</td><td>atmospheric</td><td>neutrino</td><td>distortion</td></tr><tr><td>41</td><td>connect</td><td>magnetic</td><td>plasma</td><td>controller</td></tr><tr><td>42</td><td>convert</td><td>phased</td><td>interface</td><td>actuator</td></tr><tr><td>43</td><td>modify</td><td>rapid</td><td>data</td><td>continuum</td></tr><tr><td>44</td><td>counteract</td><td>ionic</td><td>E-M</td><td>banks</td></tr><tr><td>45</td><td>balance</td><td>astrophysical</td><td>nano</td><td>harmonic</td></tr><tr><td>46</td><td>harmonise</td><td>nucleonic</td><td>polaron</td><td>mutation</td></tr><tr><td>51</td><td>reset</td><td>accelerated</td><td>positron</td><td>invariance</td></tr><tr><td>52</td><td>recalibrate</td><td>anterior</td><td>override</td><td>seal</td></tr><tr><td>53</td><td>reroute</td><td>primary</td><td>access</td><td>container</td></tr><tr><td>54</td><td>overload</td><td>secondary</td><td>load</td><td>generator</td></tr><tr><td>55</td><td>fluctuate</td><td>tertiary</td><td>tachyon</td><td>filter</td></tr><tr><td>56</td><td>concentrate</td><td>backup</td><td>charge</td><td>safeguard</td></tr><tr><td>61</td><td>extend</td><td>master</td><td>compression</td><td>manifold</td></tr><tr><td>62</td><td>redirect</td><td>emergency</td><td>diagnostic</td><td>buffer</td></tr><tr><td>63</td><td>correlate</td><td>warp</td><td>mass</td><td>accelerator</td></tr><tr><td>64</td><td>synchronise</td><td>trifold</td><td>nanite</td><td>booster</td></tr><tr><td>65</td><td>pressurise</td><td>psitronic</td><td>proton</td><td>transponder</td></tr><tr><td>66</td><td>recollimate</td><td>thermal</td><td>radiation</td><td>stabilizer</td></tr></tbody></table><span>",
              // Specified location to perform substitution.
              "XPath": "//*[@id='h.18df475c58b939d3_11']/div[2]"
            }
          ],
          // Symbol to use for campaign entries derived from the source data.
          "TagSymbol": "~",
          // The starting location in the document to begin processing.
          // This helps skip content like menus and other template items.
          "XPath": "//div[@role='main'][1]"
        },
        ...
```
