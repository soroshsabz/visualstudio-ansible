// ITNOA

const { spawn } = require("child_process");
const stdin = process.openStdin()

process.stdout.write('Enter name: ')

stdin.addListener('data', text => {
  const name = text.toString().trim()
  console.log('Your name is: ' + name)

  stdin.pause() // stop reading
})

console.log('salam');
//process.stdout.write("salam");
//spawn("npx", ["ansible-language-server"].concat(" --stdio"), { stdio: 'inherit' });
