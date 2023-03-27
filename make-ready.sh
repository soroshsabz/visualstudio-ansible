# ITNOA
#!/bin/bash

git submodule update --init --recursive

# ansible-language-server needs nodejs 14 or above
curl -sL https://deb.nodesource.com/setup_14.x | sudo bash -

sudo apt install nodejs yarn -y
