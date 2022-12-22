package com.sitaram.sitaram;

import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.os.Bundle;
import android.view.MenuItem;
import android.widget.Toast;
import androidx.annotation.NonNull;
import com.google.android.material.bottomnavigation.BottomNavigationView;
import com.google.android.material.navigation.NavigationBarView;
import com.google.android.material.navigation.NavigationView.OnNavigationItemSelectedListener;

public class FragmentRollActivity extends AppCompatActivity {

    BottomNavigationView bottomNavigationView;

    // create the object of all the fragment class
    HomeFragment homeFragment =  new HomeFragment();
    ProfileFragment profileFragment = new ProfileFragment();
    ContactFragment contactFragment = new ContactFragment();
    SkillsFragment skillsFragment = new SkillsFragment();
    HobbiesFragment hobbiesFragment = new HobbiesFragment();

    @SuppressLint("MissingInflatedId")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_roll_fragment);

        bottomNavigationView = findViewById(R.id.bottomNavigationView);
        // bottomNavigationView.setOnItemSelectedListener(this);

        toastMassage("Welcome to my Portfolio App !!");
        getSupportFragmentManager().beginTransaction().replace(R.id.frame_layout, homeFragment).commit();
        bottomNavigationView.setOnItemSelectedListener(new NavigationBarView.OnItemSelectedListener() {
            @Override
            public boolean onNavigationItemSelected(@NonNull MenuItem item) {
                if(item.getItemId() == R.id.navbar_ic_profile){
                    // display the profile profile fragment layout
                    toastMassage("This is profile page");
                    getSupportFragmentManager().beginTransaction().replace(R.id.frame_layout, profileFragment).commit();
                    return true;
                }else if(item.getItemId() == R.id.navbar_ic_content){
                    // display the profile profile fragment layout and show to toast message
                    toastMassage("This is contact page");
                    getSupportFragmentManager().beginTransaction().replace(R.id.frame_layout, contactFragment).commit();
                    return true;
                }else if(item.getItemId() == R.id.navbar_ic_skill){
                    // display the skill fragment layout
                    toastMassage("This is skill page");
                    getSupportFragmentManager().beginTransaction().replace(R.id.frame_layout, skillsFragment).commit();
                    return true;
                }else if(item.getItemId() == R.id.navbar_ic_hobbies){
                    // display the profile profile fragment layout
                    toastMassage("This is hobbies page");
                    getSupportFragmentManager().beginTransaction().replace(R.id.frame_layout, hobbiesFragment).commit();
                    return true;
                }else{
                    // when click the home icon display the profile profile fragment layout
                    toastMassage("This is home page");
                    getSupportFragmentManager().beginTransaction().replace(R.id.frame_layout, homeFragment).commit();
                    return true;
                }
            }
        });
    }

    public void toastMassage(String message){
        // display the profile profile fragment layout and show to toast message
        Toast.makeText(FragmentRollActivity.this, message, Toast.LENGTH_SHORT).show();
    }
}