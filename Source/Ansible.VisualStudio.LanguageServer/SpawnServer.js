// ITNOA

const { spawn } = require("child_process");

spawn("npx", ["ansible-language-server"].concat(process.argv[2]), { stdio: 'inherit' });
