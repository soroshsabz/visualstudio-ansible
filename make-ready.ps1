# ITNOA

git submodule update --init --recursive

Set-Location "Dependency/ansible-language-server"
npm install .
npm ci .
npm compile
