# CosmosDB and Functions 


## Console app

https://pmichaels.net/di-console-app/

https://debajmecrm.com/how-to-use-app-config-or-configuration-files-in-net-core-console-application/


## Cosmos

https://code-maze.com/azure-cosmos-db-with-asp-net-core-web-api/



## Things to try

	- Console with DI to do things like send queue messages
	- Functions app to update CosmosDB (emulated)
		- command line reference - https://learn.microsoft.com/en-us/azure/cosmos-db/emulator-command-line-parameters#manage-the-emulator-with-command-line-syntax
			Import-Module "$env:ProgramFiles\Azure Cosmos DB Emulator\PSModules\Microsoft.Azure.CosmosDB.Emulator"
			
		- add event grid and servicebus later
	- Razor app to get data from Cosmos
	- README with mermaid diagram

 - Maths
	https://github.blog/2022-05-19-math-support-in-markdown/

**Here is some maths!**

```math
\sqrt{3}
```

    When $a \ne 0$, there are two solutions to $(ax^2 + bx + c = 0)$ and they are 
$$ x = {-b \pm \sqrt{b^2-4ac} \over 2a} $$

**The Cauchy-Schwarz Inequality**

$$\left( \sum_{k=1}^n a_k b_k \right)^2 \leq \left( \sum_{k=1}^n a_k^2 \right) \left( \sum_{k=1}^n b_k^2 \right)$$



 - Mermaid
   - https://github.blog/2022-02-14-include-diagrams-markdown-files-mermaid/

    ```mermaid
      graph TD;
          A-->B;
          A-->C;
          B-->D;
          C-->D;
    ```
 
```mermaid
sequenceDiagram
    participant dotcom
    participant iframe
    participant viewscreen
    dotcom->>iframe: loads html w/ iframe url
    iframe->>viewscreen: request template
    viewscreen->>iframe: html & javascript
    iframe->>dotcom: iframe ready
    dotcom->>iframe: set mermaid data on iframe
    iframe->>iframe: render mermaid
```

 

