package com.sitaram.sitaram;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import androidx.appcompat.app.AppCompatActivity;

public class MainActivity extends AppCompatActivity {
    Button button;
    int counter = 1;
    FirstViewPagerFragment firstViewPagerFragment = new FirstViewPagerFragment();
    SecondViewPAgerFragment secondViewPAgerFragment = new SecondViewPAgerFragment();
    FinalViewPagerFragment finalViewPagerFragment = new FinalViewPagerFragment();
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        button = findViewById(R.id.btn_main);
        getSupportFragmentManager().beginTransaction().replace(R.id.frame_layoutSlider, firstViewPagerFragment).commit();

        // button click to go the home FragmentRollActivity page
        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                switch (counter){
                    case 1:
                        getSupportFragmentManager().beginTransaction().replace(R.id.frame_layoutSlider, secondViewPAgerFragment).commit();
                        break;
                    case 2:
                        getSupportFragmentManager().beginTransaction().replace(R.id.frame_layoutSlider, finalViewPagerFragment).commit();
                        break;
                    case 3:
                        Intent intent = new Intent(MainActivity.this,FragmentRollActivity.class);
                        startActivity(intent);
                        System.out.println("counter : "+counter);
                        finish();
                }
                counter++;
            }
        });
    }
}