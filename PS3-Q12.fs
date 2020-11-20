type Record = {GPA: unit -> float; addCredit: float -> unit; addGradePoints: float -> unit};;

let student =
    let creditHours = ref 0.0
    let gradePoints = ref 0.0
    {GPA = fun () -> (!gradePoints * 3.0 / !creditHours)
     addCredit = fun n -> creditHours := n + !creditHours
     addGradePoints = fun n -> gradePoints := n + !gradePoints}

//Testing
student.addCredit(3.0)
student.addGradePoints(3.5)
student.addCredit(3.0)
student.addGradePoints(3.5)
student.addCredit(4.0)
student.addGradePoints(4.0)
student.addCredit(3.0)
student.addGradePoints(4.0)
print "%A" (student.GPA())