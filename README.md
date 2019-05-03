# SPAUploadDownload
Simple Page Application for upload download files

# Como rodar o projeto:

Inicie o back-end com o visual studio e defina o projeto .HOST como projeto inicial, habilite a migration e de o commando update-database no terminal do nuget logo após de start e verifique a porta.

Abra o front end com o visual studio code, no terminal utitize o comando npm install logo após vá em app-constants e verifique a porta da API que esta rodando no seu back-end se estiver tudo ok, utilizar o comando ng server -o para rodar o front end.

Caso de algum problema de CORS por gentileza utilizar: 
https://chrome.google.com/webstore/detail/allow-control-allow-origi/nlfbmbojpeacfghkpbjhddihlkkiljbi


# Autenticação

Para se autenticar existem dois tipo de usuários mocados, um admmin e outro comum. Apenas usuários admin pode fazer upload de arquivo.

email: admin@admin.com
senha: 123

email: comum@comum.com
senha: 123
