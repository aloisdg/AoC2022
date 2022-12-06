let findMarkerIndex (signal: string) (marker: int) =
    let rec loop i =
        let current = signal.[i..marker] |> Seq.distinct |> Seq.length
        if  current = marker
        then i + marker
        else (loop (i + 1))
      
    loop 0

printfn "%i" (findMarkerIndex "bvwbjplbgvbhsrlpgdmjqwftvncz" 14)
