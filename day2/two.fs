let s = """A Y
B X
C Z"""

let score x =
    match x with 
    | "A Y" -> 1 + 3
    | "B Y" -> 2 + 3
    | "C Y" -> 3 + 3
    | "A X" -> 3 + 0
    | "B X" -> 1 + 0
    | "C X" -> 2 + 0
    | "A Z" -> 2 + 6
    | "B Z" -> 3 + 6
    | "C Z" -> 1 + 6
    | _ -> 0

s.Split "\n"
|> Array.sumBy score
|> printfn "%i"
