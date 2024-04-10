package com.example.demo;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class hello_controller {
    @GetMapping("/")
    public String index(){
        return "Hello world!";
    }
}

