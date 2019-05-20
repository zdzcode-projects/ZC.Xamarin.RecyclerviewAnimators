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
using Android.Widget;
using JP.Wasabeef.Recyclerview.Animators;

namespace XamarinAndroidExample
{
    [Activity(Label = "AnimatorSampleActivity")]
    public class AnimatorSampleActivity : AppCompatActivity
    {
        private MainAdapter _mainAdapter;
        private RecyclerView recyclerView;
        private Spinner spinner;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _mainAdapter = new MainAdapter(this, SampleData.LIST.ToList());




            SetContentView(Resource.Layout.activity_animator);


            SetSupportActionBar(FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.tool_bar));


            recyclerView = FindViewById<RecyclerView>(Resource.Id.list);

            recyclerView.SetItemAnimator(new SlideInLeftAnimator());

            recyclerView.SetLayoutManager(new LinearLayoutManager(this));

            recyclerView.SetAdapter(_mainAdapter);

            spinner = FindViewById<Spinner>(Resource.Id.spinner);

            spinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, Enum.GetNames(typeof(ItemItemAnimationType)));            

            spinner.ItemSelected += Spinner_ItemSelected;


            //    for (type in Type.values())
            //            {
            //                spinnerAdapter.add(type.name)
            //    }
            //            spinner.adapter = spinnerAdapter
            //    spinner.onItemSelectedListener = object : AdapterView.OnItemSelectedListener {
            //      override fun onItemSelected(parent: AdapterView<*>, view: View, position: Int, id: Long)
            //        {
            //            recyclerView.itemAnimator = Type.values()[position].animator
            //        recyclerView.itemAnimator!!.addDuration = 500
            //        recyclerView.itemAnimator!!.removeDuration = 500
            //      }

            //        override fun onNothingSelected(parent: AdapterView<*>)
            //        {
            //            // no-op
            //        }
            //    }

            FindViewById<View>(Resource.Id.add).Click += AnimatorSampleActivity_Click;

            FindViewById<View>(Resource.Id.del).Click += AnimatorSampleActivity_Click1;
        }

        private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            switch ((ItemItemAnimationType)e.Position)
            {
                case ItemItemAnimationType.FadeIn: recyclerView.SetItemAnimator(new FadeInAnimator()); break;
                case ItemItemAnimationType.FadeInDown: recyclerView.SetItemAnimator(new FadeInDownAnimator()); break;
                case ItemItemAnimationType.FadeInUp: recyclerView.SetItemAnimator(new FadeInUpAnimator()); break;
                case ItemItemAnimationType.FadeInLeft: recyclerView.SetItemAnimator(new FadeInLeftAnimator()); break;
                case ItemItemAnimationType.FadeInRight: recyclerView.SetItemAnimator(new FadeInRightAnimator()); break;
                case ItemItemAnimationType.Landing: recyclerView.SetItemAnimator(new LandingAnimator()); break;
                case ItemItemAnimationType.ScaleIn: recyclerView.SetItemAnimator(new ScaleInAnimator()); break;
                case ItemItemAnimationType.ScaleInTop: recyclerView.SetItemAnimator(new ScaleInTopAnimator()); break;
                case ItemItemAnimationType.ScaleInBottom: recyclerView.SetItemAnimator(new ScaleInBottomAnimator()); break;
                case ItemItemAnimationType.ScaleInLeft: recyclerView.SetItemAnimator(new ScaleInLeftAnimator()); break;
                case ItemItemAnimationType.ScaleInRight: recyclerView.SetItemAnimator(new ScaleInRightAnimator()); break;
                case ItemItemAnimationType.FlipInTopX: recyclerView.SetItemAnimator(new FlipInTopXAnimator()); break;
                case ItemItemAnimationType.FlipInBottomX: recyclerView.SetItemAnimator(new FlipInBottomXAnimator()); break;
                case ItemItemAnimationType.FlipInLeftY: recyclerView.SetItemAnimator(new FlipInLeftYAnimator()); break;
                case ItemItemAnimationType.FlipInRightY: recyclerView.SetItemAnimator(new FlipInRightYAnimator()); break;
                case ItemItemAnimationType.SlideInLeft: recyclerView.SetItemAnimator(new SlideInLeftAnimator()); break;
                case ItemItemAnimationType.SlideInRight: recyclerView.SetItemAnimator(new SlideInRightAnimator()); break;
                case ItemItemAnimationType.SlideInDown: recyclerView.SetItemAnimator(new SlideInDownAnimator()); break;
                case ItemItemAnimationType.SlideInUp: recyclerView.SetItemAnimator(new SlideInUpAnimator()); break;
                case ItemItemAnimationType.OvershootInRight: recyclerView.SetItemAnimator(new OvershootInRightAnimator(1.0f)); break;
                case ItemItemAnimationType.OvershootInLeft: recyclerView.SetItemAnimator(new OvershootInLeftAnimator(1.0f)); break;
                default:
                    recyclerView.SetItemAnimator(new FadeInAnimator());
                    break;

            }


            //    recyclerView.itemAnimator = Type.values()[position].animator
            recyclerView.GetItemAnimator().AddDuration = 500;
            recyclerView.GetItemAnimator().RemoveDuration  = 500;
        }

        private void AnimatorSampleActivity_Click1(object sender, EventArgs e)
        {
            _mainAdapter.remove(1);
        }

        private void AnimatorSampleActivity_Click(object sender, EventArgs e)
        {
            _mainAdapter.add("newly added item", 1);            
        }
    }


    public enum ItemItemAnimationType {
        FadeIn                 ,
        FadeInDown             ,
        FadeInUp               ,
        FadeInLeft             ,
        FadeInRight            ,
        Landing                ,
        ScaleIn                ,
        ScaleInTop             ,
        ScaleInBottom          ,
        ScaleInLeft            ,
        ScaleInRight           ,
        FlipInTopX             ,
        FlipInBottomX          ,
        FlipInLeftY            ,
        FlipInRightY           ,
        SlideInLeft            ,
        SlideInRight           ,
        SlideInDown            ,
        SlideInUp              ,
        OvershootInRight       ,
        OvershootInLeft        ,
    }

}

