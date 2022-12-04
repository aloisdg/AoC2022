// https://tio.run/##LYzLDsIgEEX3fMWkm0LUCb41Td278A@6KLZEayoQQNO/R6bxLk7uIzMv9VWh84OLK2N7nVJnTYgQoIZ2LaVkG8KWwHYz98TDbI/EE@E8ZzqQbcUYPbGjxtE@@E3FJ77VxBExYHDjEHnRmMYUIteOT1BfYPoPZWNKgV73n05zrpZwFzQ75YO@mshzXECupciqUvoB

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
