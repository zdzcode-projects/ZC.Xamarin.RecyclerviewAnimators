using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using JP.Wasabeef.Recyclerview.Adapters;
using JP.Wasabeef.Recyclerview.Animators;

namespace XamarinAndroidExample
{
    [Activity(Label = "AdapterSampleActivity")]
    public class AdapterSampleActivity : AppCompatActivity
    {
        private RecyclerView recyclerView;
        private Spinner spinner;
        private MainAdapter adapter;
        private AlphaInAnimationAdapter alphaInAnimationAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {            
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.activity_adapter);

            SetSupportActionBar(FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.tool_bar));

            recyclerView = FindViewById<RecyclerView>(Resource.Id.list);
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));

            spinner = FindViewById<Spinner>(Resource.Id.spinner);

            spinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, Enum.GetNames(typeof(AnimationType)));


            spinner.ItemSelected += Spinner_ItemSelected;

            recyclerView.SetItemAnimator(new FadeInAnimator());

            adapter = new MainAdapter(this, SampleData.LIST.ToList());

            alphaInAnimationAdapter = new AlphaInAnimationAdapter(adapter);

            alphaInAnimationAdapter.SetFirstOnly(true);
            alphaInAnimationAdapter.SetDuration(500);
            alphaInAnimationAdapter.SetInterpolator(new OvershootInterpolator(.5f));

            recyclerView.SetAdapter(alphaInAnimationAdapter);
        }

        private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            AnimationAdapter recyclerViewAdapter;

            switch ((AnimationType)e.Position)
            {
                case AnimationType.AlphaIn:
                    recyclerViewAdapter = new AlphaInAnimationAdapter(new MainAdapter(this, SampleData.LIST.ToList()));
                    break;
                case AnimationType.ScaleIn:
                    recyclerViewAdapter = new ScaleInAnimationAdapter(new MainAdapter(this, SampleData.LIST.ToList()));
                    break;
                case AnimationType.SlideInBottom:
                    recyclerViewAdapter = new SlideInBottomAnimationAdapter(new MainAdapter(this, SampleData.LIST.ToList()));
                    break;
                case AnimationType.SlideInLeft:
                    recyclerViewAdapter = new SlideInLeftAnimationAdapter(new MainAdapter(this, SampleData.LIST.ToList()));
                    break;
                case AnimationType.SlideInRight:
                default:
                    recyclerViewAdapter = new SlideInRightAnimationAdapter(new MainAdapter(this, SampleData.LIST.ToList()));
                    break;
            }

            recyclerView.SetAdapter(recyclerViewAdapter);

            recyclerViewAdapter.SetFirstOnly(true);
            recyclerViewAdapter.SetDuration(500);
            recyclerViewAdapter.SetInterpolator(new OvershootInterpolator(.5f));
        }


        public enum AnimationType
        {
            AlphaIn = 0,
            ScaleIn = 1,
            SlideInBottom = 2,
            SlideInLeft = 3,
            SlideInRight = 4
        }
    }
}