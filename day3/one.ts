const half = (s: string) => [s.slice(0, s.length / 2), s.slice(s.length / 2)];
const intersect = (a: string, b: string) => [...a].filter(value => b.includes(value));
const priorize = (c: number) => c - (c > 96 ? 96 : 38);

const s = `vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw`

const r = s.split('\n')
    .map(half)
    .map(([a, b]) => intersect(a, b))
    .map(c => c[0].charCodeAt(0))
    .reduce((a, b) => a + priorize(b), 0)
    
console.log(r)
