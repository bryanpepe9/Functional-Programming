let altSeries n =
    let rec aux index =
        if index <= n then
            if index % 2 = 1 then
                let result = sprintf "%.3f," (1.0/(2.0**float(index)))
                result + aux (index + 1)
            else
                let result = sprintf "%.3f," (-1.0/(2.0**float(index)))
                result + aux (index + 1)

let altInfiniteStr =
    Seq.initInfinite (fun index -> 1.0/(2.0**float(index+1) * (if( (index+1) % 2 <> 0) then 1.0 else -1.0)))


