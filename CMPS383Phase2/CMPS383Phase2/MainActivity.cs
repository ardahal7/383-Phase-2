using Android.App;
using Android.Widget;
using Android.Content.PM;
using Android.Graphics.Drawables;
using Android.OS;
using Java.Sql;
using RiotSharp;
using System.Collections.Generic;
using Android.Util;

namespace CMPS383Phase2
{




    [Activity(Label = "CMPS383Phase2", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.Portrait)]

public class MainActivity : Activity
    {
        public RiotApi api = RiotApi.GetInstance("RGAPI-cc2a5a60-fbfc-4a0e-951a-e866b872b307");
        public Region region = Region.na;



        private EditText editSearchName;
        private Button buttonSearchButton;

        private int profileIconId;
        private string profileIconName;

        //text for get summoner
        private TextView textId;
        private TextView textName;
        private TextView textRevisionDate;
        private TextView textSummonerLevel;
        private ImageView profileIcon;

        private TextView textChampionName;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Screen);

            this.editSearchName = FindViewById<EditText>(Resource.Id.editSearchName);
            this.buttonSearchButton = FindViewById<Button>(Resource.Id.buttonSearchButton);

            this.buttonSearchButton.Click += ButtonSearchButtonClick;


        }

        private void ButtonSearchButtonClick(object sender, System.EventArgs e)
        {
            Info infoObject = new Info();
            EditText searchLayout = FindViewById<EditText>(Resource.Id.editSearchName);
            string search = searchLayout.Text;
            infoObject.GetSummoner(region, search);

            
            textId = (TextView)infoObject.id;
            textName = (TextView)infoObject.name;
            textRevisionDate = (TextView)infoObject.revisionDate.ToString();
            textSummonerLevel = (TextView)infoObject.summonerLevel;
            textChampionName = (TextView)infoObject.championName;
            profileIcon = (ImageView) infoObject.profileIcon;

            infoObject.GetGame();




        }


    }
}

