using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CMPS383Phase2
{
    class GameListAdapter : BaseAdapter<Info>
    {

        private Context context;
        private LayoutInflater inflater;
        private List<Info> infoList;

        public GameListAdapter(List<Info> infoList, Context context)
        {
            this.infoList = infoList;
            this.context = context;
        }

        public GameListAdapter()
        {

        }

        public override Android.Views.View GetView(int number, Android.Views.View convertView, ViewGroup root)
        {
            if (inflater == null)
            {
                inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            }
            if (convertView == null)
            {
                convertView = inflater.Inflate(Resource.Layout.GameList, root, true);
            }
            TextView gameId = convertView.FindViewById<TextView>(Resource.Id.textGameId);
            gameId.Text = infoList[number].gameId.ToString();
            return convertView;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Info this[int position]
        {
            get
            {
                return this.infoList[position];
            }
        }

        public override int Count
        {
            get
            {
                return infoList.Count;
            }
        }

    }
}