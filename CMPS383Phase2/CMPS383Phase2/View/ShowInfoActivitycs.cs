
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CMPS383Phase2
{
    class ShowInfoActivity : Activity
    {
        private ShowInfoAdapter adapter;
        private ListView listView;

        private Context context;
        private LayoutInflater inflater;

        private List<Info> infoList;

        protected override void OnCreate(Bundle savedBundle)
        {
            base.OnCreate(savedBundle);
            SetContentView(Resource.Layout.Screen);
            listView = FindViewById<ListView>(Resource.Id.layoutListView);
            adapter = new ShowInfoAdapter();
            listView.Adapter = adapter;
        }

        



    }
}