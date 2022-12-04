let isSubRange a1 a2 b1 b2 =
    (a1 >= b1 && a2 <= b2) || (a1 <= b1 && a2 >= b2)

let count predicate = Seq.filter predicate >> Seq.length 
    
let s = """2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8"""

s.Split '\n'
|> Array.map(fun x -> x.Split([|','; '-'|]) |> Array.map int)
|> count(fun x -> isSubRange x.[0] x.[1] x.[2] x.[3])
|> printfn "%i"
