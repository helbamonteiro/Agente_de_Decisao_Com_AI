# Agente_de_Decisao_Com_AI
Agente de decisão usando a IA

O que foi feito e como:

Arquitetura Orientada a Agentes: Utilizei Clean Architecture para manter o núcleo do negócio isolado de detalhes técnicos. A IA atua como um "Parser Semântico", transformando linguagem natural em comandos estruturados.

Padrão Strategy (Tool Registry): Implementei o padrão Strategy para que o agente possa acionar "ferramentas" específicas (como suspender ou cancelar assinaturas) de forma dinâmica, baseada na decisão da IA.

Contratos Determinísticos: Através de Prompt Engineering, forcei o LLM a responder exclusivamente em JSON. Isso garante que o sistema C# receba dados tipados e seguros, evitando as famosas "alucinações".

Guardrails de Segurança: Nenhuma decisão da IA vai direto para o banco de dados sem passar por uma camada de validação que garante o cumprimento das regras de negócio corporativas.

🧰 Ferramentas Utilizadas:

Visual Studio: Minha central de comando para desenvolvimento em C# e ASP.NET Core, onde gerencio a injeção de dependência e a lógica dos Use Cases.

Postman: Essencial para testar os endpoints da API, validando os Payloads de entrada e garantindo que o fluxo entre o comando do usuário e a resposta da IA esteja perfeito.

OpenAI API / Ollama: Os motores de inteligência que processam a lógica por trás das decisões.
