package br.edu.unidavi.tomararedearduino_1;

import java.io.BufferedInputStream;
import java.io.BufferedReader;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;
import java.net.URLConnection;

import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;

import android.app.Activity;
import android.graphics.Canvas;
import android.graphics.ColorFilter;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.ToggleButton;

public class MainActivity extends Activity implements OnClickListener {

	private static final String ip = "http://192.168.100.110/";
    private ToggleButton btnAmarelo;
    private ToggleButton btnVerde;
    private ToggleButton btnVermelho;


	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

        btnVermelho = (ToggleButton) findViewById(R.id.btnVermelho);
        btnAmarelo  = (ToggleButton) findViewById(R.id.btnAmarelo);
        btnVerde    = (ToggleButton) findViewById(R.id.btnVerde);

        btnVermelho.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View view) {
                if (btnVermelho.isChecked()){
                    Thread t = new Thread() {
                        public void run() {
                            try {
                                URL url = new URL( ip + "?ve=1");
                                URLConnection conn = url.openConnection();
                                BufferedReader rd = new BufferedReader( new InputStreamReader( conn.getInputStream() ) );
                            } catch (Exception e) {
                                Log.e("BUTTON LIGAR", "ERRO");
                                e.printStackTrace();
                            }
                        }
                    };
                    t.start();
                } else {
                    Thread t = new Thread() {
                        public void run() {
                            try {
                                URL url = new URL( ip + "?ve=0");
                                URLConnection conn = url.openConnection();
                                BufferedReader rd = new BufferedReader( new InputStreamReader( conn.getInputStream() ) );
                            } catch (Exception e) {
                                Log.e("BUTTON LIGAR", "ERRO");
                                e.printStackTrace();
                            }
                        }
                    };
                    t.start();

                }
            }
        });


        btnAmarelo.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View view) {
                if (btnAmarelo.isChecked()){
                    Thread t = new Thread() {
                        public void run() {
                            try {
                                URL url = new URL( ip + "?am=1");
                                URLConnection conn = url.openConnection();
                                BufferedReader rd = new BufferedReader( new InputStreamReader( conn.getInputStream() ) );
                            } catch (Exception e) {
                                Log.e("BUTTON LIGAR", "ERRO");
                                e.printStackTrace();
                            }
                        }
                    };
                    t.start();
                } else {
                    Thread t = new Thread() {
                        public void run() {
                            try {
                                URL url = new URL( ip + "?am=0");
                                URLConnection conn = url.openConnection();
                                BufferedReader rd = new BufferedReader( new InputStreamReader( conn.getInputStream() ) );
                            } catch (Exception e) {
                                Log.e("BUTTON LIGAR", "ERRO");
                                e.printStackTrace();
                            }
                        }
                    };
                    t.start();

                }
            }
        });


        btnVerde.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View view) {
                if (btnVerde.isChecked()){
                    Thread t = new Thread() {
                        public void run() {
                            try {
                                URL url = new URL( ip + "?vd=1");
                                URLConnection conn = url.openConnection();
                                BufferedReader rd = new BufferedReader( new InputStreamReader( conn.getInputStream() ) );
                            } catch (Exception e) {
                                Log.e("BUTTON LIGAR", "ERRO");
                                e.printStackTrace();
                            }
                        }
                    };
                    t.start();
                } else {
                    Thread t = new Thread() {
                        public void run() {
                            try {
                                URL url = new URL( ip + "?vd=0");
                                URLConnection conn = url.openConnection();
                                BufferedReader rd = new BufferedReader( new InputStreamReader( conn.getInputStream() ) );
                            } catch (Exception e) {
                                Log.e("BUTTON LIGAR", "ERRO");
                                e.printStackTrace();
                            }
                        }
                    };
                    t.start();

                }
            }
        });
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.activity_main, menu);
		return true;
	}

	@Override
	public void onClick(View v) {
		// TODO Auto-generated method stub

	}


}
