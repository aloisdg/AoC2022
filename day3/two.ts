const range = (n: number) => Array.from(Array(n).keys());
const chunk = (l: Array<string>, n: number) => range(Math.ceil(l.length/n)).map((x,i) => l.slice(i*n,i*n+n));
const intersect = (a: string, b: string) => [...a].find(value => b.includes(value));
const priorize = (c: number) => c - (c > 96 ? 96 : 38);

const s = `vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw`

const r = chunk(s.split('\n'), 3)
    .map(([a, b, c]) => intersect(intersect(a, b), c))
    .map(c => c.charCodeAt(0))
    .reduce((a,b) => a + priorize(b), 0)

console.log(r)
