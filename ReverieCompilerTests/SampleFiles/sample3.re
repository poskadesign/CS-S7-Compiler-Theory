func fun2():
    ret fun1(1,2,   3)

func fun1(x, y, z):


    temp = x + z * 4 + x
    ret temp + y

fun2()
e = 4