package com.sitaram.sitaram;

import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.os.Bundle;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;
import androidx.annotation.NonNull;
import com.google.android.material.bottomnavigation.BottomNavigationView;
import com.google.android.material.navigation.NavigationBarView;

public class FragmentRollActivity extends AppCompatActivity {

    Button btnSetting;
    BottomNavigationView bottomNavigationView;
    TextView textView;

    // create the object of all the fragment class
    HomeFragment homeFragment =  new HomeFragment();
    ProfileFragment profileFragment = new ProfileFragment();
    ContactFragment contactFragment = new ContactFragment();
    SkillsFragment skillsFragment = new SkillsFragment();
    HobbiesFragment hobbiesFragment = new HobbiesFragment();

    @SuppressLint({"MissingInflatedId", "SetTextI18n"})
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_roll_fragment);

        // initial the  variable
        btnSetting = findViewById(R.id.btnSetting);
        bottomNavigationView = findViewById(R.id.bottomNavigationView);
        textView = findViewById(R.id.tvTitle);

        // set the automatic home page
        toastMassage("Welcome to my Portfolio App !!");
        textView.setText("Home View");
        getSupportFragmentManager().beginTransaction().replace(R.id.frame_layout, homeFragment).commit();
        bottomNavigationView.setOnItemSelectedListener(new NavigationBarView.OnItemSelectedListener() {
            @SuppressLint("SetTextI18n")
            @Override
            public boolean onNavigationItemSelected(@NonNull MenuItem item) {
                if(item.getItemId() == R.id.navbar_ic_profile){
                    // display the  profile fragment layout
                    toastMassage("This is profile page");
                    textView.setText("Profile View");
                    getSupportFragmentManager().beginTransaction().replace(R.id.frame_layout, profileFragment).commit();
                    return true;
                }else if(item.getItemId() == R.id.navbar_ic_content){
                    // display the contact fragment layout and show to toast message
                    toastMassage("This is contact page");
                    textView.setText("Contact View");
                    getSupportFragmentManager().beginTransaction().replace(R.id.frame_layout, contactFragment).commit();
                    return true;
                }else if(item.getItemId() == R.id.navbar_ic_skill){
                    // display the skill fragment layout show to toast message
                    toastMassage("This is skill page");
                    textView.setText("Skill View");
                    getSupportFragmentManager().beginTransaction().replace(R.id.frame_layout, skillsFragment).commit();
                    return true;
                }else if(item.getItemId() == R.id.navbar_ic_hobbies){
                    // display the hobbies fragment layout show to toast message
                    toastMassage("This is hobbies page");
                    textView.setText("Hobbies View");
                    getSupportFragmentManager().beginTransaction().replace(R.id.frame_layout, hobbiesFragment).commit();
                    return true;
                }else{
                    // when click the home display the home fragment layout show to toast message
                    toastMassage("This is home page");
                    textView.setText("Home View");
                    getSupportFragmentManager().beginTransaction().replace(R.id.frame_layout, homeFragment).commit();
                    return true;
                }
            }
        });

        // logout the app press the btnSetting
        btnSetting.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // display the AlertDialog box for app log out option
                AlertDialog.Builder builder = new AlertDialog.Builder(FragmentRollActivity.this);
                builder.setTitle("Logout");
                builder.setMessage("Are you sure you want to logout?");
                // press the yes the logout the app
                builder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int i) {
                        Toast.makeText(FragmentRollActivity.this, "Successfully logout.", Toast.LENGTH_SHORT).show();
                        finish();
                    }
                });
                // press the No then cancel to logout the app
                builder.setNegativeButton("No", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                        dialogInterface.dismiss();
                    }
                });
                builder.show();
            }
        });
    }

    // set ht toast message
    public void toastMassage(String message){
        // display the profile profile fragment layout and show to toast message
        Toast.makeText(FragmentRollActivity.this, message, Toast.LENGTH_SHORT).show();
    }
}