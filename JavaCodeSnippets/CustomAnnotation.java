public class UseCase{
@Target(ElementType.METHOD)
@Retention(RetentionPolicy.RUNTIME)
public @interface UseCases{
    public String id();
    public String description() default "no description";
}
}

package com.java.api;

import com.java.api.UseCase.UseCases;

/**
 * 使用注解：
 * 
 * */
public class PasswordUtils {
    @UseCases(id="47",description="Passwords must contain at least one numeric")
     public boolean validatePassword(String password) {
         return (password.matches("\\w*\\d\\w*"));
     }

     @UseCases(id ="48")
     public String encryptPassword(String password) {
         return new StringBuilder(password).reverse().toString();
     }
}

package com.java.api;
import java.lang.reflect.Method;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

import com.java.api.UseCase.UseCases;

/**
 *解析注解：
 * 
 * */
public class UserCaseTest {
public static void main(String[] args) {
     List<Integer> useCases = new ArrayList<Integer>();
     Collections.addAll(useCases, 47, 48, 49, 50);
     trackUseCases(useCases, PasswordUtils.class);
}
public static void trackUseCases(List<Integer> useCases, Class<?> cl) {
    for (Method m : cl.getDeclaredMethods()) {
        //获得注解的对象
        UseCases uc = m.getAnnotation(UseCases.class);
        if (uc != null) {
            System.out.println("Found Use Case:" + uc.id() + " "
                        + uc.description());
            useCases.remove(new Integer(uc.id()));
        }
    }
    for (int i : useCases) {
        System.out.println("Warning: Missing use case-" + i);
    }
}
}
