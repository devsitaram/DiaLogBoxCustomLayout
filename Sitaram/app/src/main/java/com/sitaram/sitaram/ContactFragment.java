package com.sitaram.sitaram;

import android.app.SearchManager;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

public class ContactFragment extends Fragment {

    // variable declare the button
    Button btnSearch;
    Button btnPhone;
    Button btnGmail;

    // variable declare of textFields
    private EditText txtSearch;
    private EditText txtPhoneNum;
    private EditText txtTo, txtSubject, txtDescription;
    private View mainView;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        mainView =  inflater.inflate(R.layout.fragment_contact, container, false);
        return mainView;
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        // getText find view by id for the text fields values
        txtSearch = mainView.findViewById(R.id.editTextSearch);
        txtPhoneNum = mainView.findViewById(R.id.editTextPhone);
        txtTo = mainView.findViewById(R.id.editTextEmailAddress);
        txtSubject= mainView.findViewById(R.id.editTextSubject);
        txtDescription = mainView.findViewById(R.id.editTextDescriptions);

        Button btnSearch = mainView.findViewById(R.id.ic_search);
        Button btnPhone = mainView.findViewById(R.id.ic_contact);
        Button btnGmail = mainView.findViewById(R.id.ic_sendSms);


        // onClickListener methods call
        btnPhone.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                // Toast.makeText(HomeFragment.this, "Let's go to phone dial.", Toast.LENGTH_SHORT).show();
                Intent call = new Intent(Intent.ACTION_DIAL);
                call.setData(Uri.parse("tel: "+txtPhoneNum));
                startActivity(call);
                txtPhoneNum.setText("");
            }
        });

        // google search anything
        btnSearch.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String searching = txtSearch.getText().toString();
                if (!searching.equals("")){
                    searchingNet(searching);
                }
            }
        });

        // some of message send by gmail
        btnGmail.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                sendMail(); // call the send email methods
            }
        });
    }

    // google search words
    private void searchingNet(String searchWords){
        try{
            Intent  intent = new Intent(Intent.ACTION_WEB_SEARCH);
            intent.putExtra(SearchManager.QUERY, searchWords);
            startActivity(intent);
        }catch (Exception ex){
            ex.printStackTrace();
            searchingNet(searchWords); // recall the methods
        }
    }

    // email send the message
    private void sendMail(){
        String recipients_list =  txtTo.getText().toString();
        String [] recipients = recipients_list.split( ","); // one time send message for multiple email address

        // get the subject and message for text fields
        String subject = txtSubject.getText().toString();
        String message = txtDescription.getText().toString();

        // intent used to put details
        Intent intent = new Intent(Intent.ACTION_SEND);
        intent.putExtra(Intent.EXTRA_EMAIL, recipients);
        intent.putExtra(Intent.EXTRA_SUBJECT, subject);
        intent.putExtra(Intent.EXTRA_TEXT, message);

        intent.setType("message/rfc8822");
        startActivity(Intent.createChooser(intent, "Choose your email?"));
    }
}