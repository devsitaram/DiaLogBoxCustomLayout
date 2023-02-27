/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package com.project.webapplication;

import java.text.DateFormat;
import java.util.Date;
import javax.faces.bean.ManagedBean;

@ManagedBean(name = "WebTimeBean")
public class WebApplication {
    // create getTime methods
    public String getTime(){
        return DateFormat.getTimeInstance(DateFormat.LONG).format(new Date());
    }
}
