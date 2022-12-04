const s = `1000
2000
3000
4000
5000
6000
7000
8000
9000
10000`;

console.log(Math.max(...s.split("\n\n").map(x => x.split('\n').reduce((a, b) => parseInt(b) + a, 0))));
