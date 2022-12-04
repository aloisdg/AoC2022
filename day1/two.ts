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

const r = s.split("\n\n").map(x => x.split('\n').reduce((a, b) => parseInt(b) + a, 0));
r.sort((a, b) => b - a);
console.log(r.slice(0, 3).reduce((a, b) => a + b));
