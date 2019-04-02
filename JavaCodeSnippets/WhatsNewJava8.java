import java.util.*;
interface Drive{
default public void takeOff(){System.out.println("Taking off!");}
}

interface FastDrive extends Fly{
default public void takeOff{}
}
