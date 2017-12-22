using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace fc.Resources
{
    public class Resources
    {
        private static IResourceProvider resourceProvider = new DbResourceProvider(); //  new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Resources.xml"));                

        public static string pageCategoryItemPrice
        {
            get
            {
                return resourceProvider.GetResource("pageCategoryItemPrice", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string pageCategoryFilterSort
        {
            get
            {
                return resourceProvider.GetResource("pageCategoryFilterSort", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string pageCategoryFilterManifacture
        {
            get
            {
                return resourceProvider.GetResource("pageCategoryFilterManifacture", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string pageCategoryFilterYear
        {
            get
            {
                return resourceProvider.GetResource("pageCategoryFilterYear", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string pageCategoryFilterDataAdd
        {
            get
            {
                return resourceProvider.GetResource("pageCategoryFilterDataAdd", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string pageCategoryBtnShow
        {
            get
            {
                return resourceProvider.GetResource("pageCategoryBtnShow", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string pageCAtegoryYearManifacture
        {
            get
            {
                return resourceProvider.GetResource("pageCAtegoryYearManifacture", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string pageCategoryManifacture
        {
            get
            {
                return resourceProvider.GetResource("pageCategoryManifacture", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string widgetLastProduct
        {
            get
            {
                return resourceProvider.GetResource("widgetLastProduct", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string widgetAdvertisement
        {
            get
            {
                return resourceProvider.GetResource("widgetAdvertisement", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a About Us.
        /// </summary>
        public static string footerAbout
        {
            get
            {
                return resourceProvider.GetResource("footerAbout", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Chosen for you.
        /// </summary>
        public static string footerChosen
        {
            get
            {
                return resourceProvider.GetResource("footerChosen", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a About.
        /// </summary>
        public static string footerLinkAbout
        {
            get
            {
                return resourceProvider.GetResource("footerLinkAbout", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Categories.
        /// </summary>
        public static string footerLinkCategories
        {
            get
            {
                return resourceProvider.GetResource("footerLinkCategories", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Contact.
        /// </summary>
        public static string footerLinkContact
        {
            get
            {
                return resourceProvider.GetResource("footerLinkContact", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a How TO.
        /// </summary>
        public static string footerLinkHowTo
        {
            get
            {
                return resourceProvider.GetResource("footerLinkHowTo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Terms of Use.
        /// </summary>
        public static string footerLinkTerms
        {
            get
            {
                return resourceProvider.GetResource("footerLinkTerms", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Useful Links.
        /// </summary>
        public static string footerUseful
        {
            get
            {
                return resourceProvider.GetResource("footerUseful", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Account.
        /// </summary>
        public static string headerAccount
        {
            get
            {
                return resourceProvider.GetResource("headerAccount", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Find.
        /// </summary>
        public static string headerBuy
        {
            get
            {
                return resourceProvider.GetResource("headerBuy", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a English.
        /// </summary>
        public static string headerEnglish
        {
            get
            {
                return resourceProvider.GetResource("headerEnglish", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a How TO.
        /// </summary>
        public static string headerHowTo
        {
            get
            {
                return resourceProvider.GetResource("headerHowTo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Italian.
        /// </summary>
        public static string headerItalian
        {
            get
            {
                return resourceProvider.GetResource("headerItalian", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Language.
        /// </summary>
        public static string headerLanguage
        {
            get
            {
                return resourceProvider.GetResource("headerLanguage", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Login.
        /// </summary>
        public static string headerLogin
        {
            get
            {
                return resourceProvider.GetResource("headerLogin", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Log Out.
        /// </summary>
        public static string headerLogOut
        {
            get
            {
                return resourceProvider.GetResource("headerLogOut", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Sell.
        /// </summary>
        public static string headerSell
        {
            get
            {
                return resourceProvider.GetResource("headerSell", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Signup.
        /// </summary>
        public static string headerSignup
        {
            get
            {
                return resourceProvider.GetResource("headerSignup", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Ads.
        /// </summary>
        public static string homeAdsCount
        {
            get
            {
                return resourceProvider.GetResource("homeAdsCount", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Browse by category.
        /// </summary>
        public static string homeCategory
        {
            get
            {
                return resourceProvider.GetResource("homeCategory", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Regular Members.
        /// </summary>
        public static string homeCounterMembers
        {
            get
            {
                return resourceProvider.GetResource("homeCounterMembers", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Regular Ads.
        /// </summary>
        public static string homeCounterRegular
        {
            get
            {
                return resourceProvider.GetResource("homeCounterRegular", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Request Ads.
        /// </summary>
        public static string homeCounterRequest
        {
            get
            {
                return resourceProvider.GetResource("homeCounterRequest", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Featured Listings.
        /// </summary>
        public static string homeFeatured
        {
            get
            {
                return resourceProvider.GetResource("homeFeatured", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a ViewMore.
        /// </summary>
        public static string homeViewMore
        {
            get
            {
                return resourceProvider.GetResource("homeViewMore", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a About Us.
        /// </summary>
        public static string pageAboutHeaderTitle
        {
            get
            {
                return resourceProvider.GetResource("pageAboutHeaderTitle", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Policy.
        /// </summary>
        public static string pageCookie
        {
            get
            {
                return resourceProvider.GetResource("pageCookie", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Faq.
        /// </summary>
        public static string pageFaq
        {
            get
            {
                return resourceProvider.GetResource("pageFaq", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a How To.
        /// </summary>
        public static string pageHowTo
        {
            get
            {
                return resourceProvider.GetResource("pageHowTo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Login.
        /// </summary>
        public static string pageLogin
        {
            get
            {
                return resourceProvider.GetResource("pageLogin", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Create an account.
        /// </summary>
        public static string pageLoginCreate
        {
            get
            {
                return resourceProvider.GetResource("pageLoginCreate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Lost your  password?.
        /// </summary>
        public static string pageLoginLostPassword
        {
            get
            {
                return resourceProvider.GetResource("pageLoginLostPassword", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Don&apos;t have account yet?.
        /// </summary>
        public static string pageLoginPromo
        {
            get
            {
                return resourceProvider.GetResource("pageLoginPromo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Add your machines for sale for free.
        /// </summary>
        public static string pageLoginPromoList1
        {
            get
            {
                return resourceProvider.GetResource("pageLoginPromoList1", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Manage your offers (add, edit and delete).
        /// </summary>
        public static string pageLoginPromoList2
        {
            get
            {
                return resourceProvider.GetResource("pageLoginPromoList2", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Inquire on machines without having to fill your contact details.
        /// </summary>
        public static string pageLoginPromoList3
        {
            get
            {
                return resourceProvider.GetResource("pageLoginPromoList3", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a An agent assists you for the sale of your machines.
        /// </summary>
        public static string pageLoginPromoList4
        {
            get
            {
                return resourceProvider.GetResource("pageLoginPromoList4", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Gain priority with each effective sale done.
        /// </summary>
        public static string pageLoginPromoList5
        {
            get
            {
                return resourceProvider.GetResource("pageLoginPromoList5", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Remember me.
        /// </summary>
        public static string pageLoginRemember
        {
            get
            {
                return resourceProvider.GetResource("pageLoginRemember", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Submit.
        /// </summary>
        public static string pageLoginSubmit
        {
            get
            {
                return resourceProvider.GetResource("pageLoginSubmit", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Register.
        /// </summary>
        public static string pageRegister
        {
            get
            {
                return resourceProvider.GetResource("pageRegister", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a I agree to the .
        /// </summary>
        public static string pageRegisterAgree
        {
            get
            {
                return resourceProvider.GetResource("pageRegisterAgree", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent sit amet porta eros, eget facilisis arcu. Duis condimentum fermentum enim, ac rutrum erat venenatis vel Morbi pharetra viverra faucibus..
        /// </summary>
        public static string pageRegisterAgreeContent
        {
            get
            {
                return resourceProvider.GetResource("pageRegisterAgreeContent", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Register.
        /// </summary>
        public static string pageRegisterBtn
        {
            get
            {
                return resourceProvider.GetResource("pageRegisterBtn", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a City.
        /// </summary>
        public static string pageRegisterCity
        {
            get
            {
                return resourceProvider.GetResource("pageRegisterCity", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Confirm Password.
        /// </summary>
        public static string pageRegisterConfirmPassword
        {
            get
            {
                return resourceProvider.GetResource("pageRegisterConfirmPassword", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Country.
        /// </summary>
        public static string pageRegisterCoutry
        {
            get
            {
                return resourceProvider.GetResource("pageRegisterCoutry", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Email.
        /// </summary>
        public static string pageRegisterEmail
        {
            get
            {
                return resourceProvider.GetResource("pageRegisterEmail", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a First Name.
        /// </summary>
        public static string pageRegisterFirstName
        {
            get
            {
                return resourceProvider.GetResource("pageRegisterFirstName", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Register for free.
        /// </summary>
        public static string pageRegisterForFree
        {
            get
            {
                return resourceProvider.GetResource("pageRegisterForFree", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Last Name.
        /// </summary>
        public static string pageRegisterLastName
        {
            get
            {
                return resourceProvider.GetResource("pageRegisterLastName", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Password.
        /// </summary>
        public static string pageRegisterPassword
        {
            get
            {
                return resourceProvider.GetResource("pageRegisterPassword", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Phone.
        /// </summary>
        public static string pageRegisterPhone
        {
            get
            {
                return resourceProvider.GetResource("pageRegisterPhone", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Security.
        /// </summary>
        public static string pageRegisterSecurity
        {
            get
            {
                return resourceProvider.GetResource("pageRegisterSecurity", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Terms of Use.
        /// </summary>
        public static string pageRegisterTermsOfUse
        {
            get
            {
                return resourceProvider.GetResource("pageRegisterTermsOfUse", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Your email here.
        /// </summary>
        public static string placeHolderEmail
        {
            get
            {
                return resourceProvider.GetResource("placeHolderEmail", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Post is free.
        /// </summary>
        public static string postFreeButton
        {
            get
            {
                return resourceProvider.GetResource("postFreeButton", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Sell your products online FOR FREE. It&apos;s easier than you think !.
        /// </summary>
        public static string postFreeSubTitle
        {
            get
            {
                return resourceProvider.GetResource("postFreeSubTitle", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Do you get anything for sell ?.
        /// </summary>
        public static string postFreeTitle
        {
            get
            {
                return resourceProvider.GetResource("postFreeTitle", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Search.
        /// </summary>
        public static string searchBuy
        {
            get
            {
                return resourceProvider.GetResource("searchBuy", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Welcome To.
        /// </summary>
        public static string searchIntroTitle
        {
            get
            {
                return resourceProvider.GetResource("searchIntroTitle", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Enter Keyword.
        /// </summary>
        public static string searchKey
        {
            get
            {
                return resourceProvider.GetResource("searchKey", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Buy and sell used industrial machinery.
        /// </summary>
        public static string searchSubTitle
        {
            get
            {
                return resourceProvider.GetResource("searchSubTitle", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Aleready a memeber?.
        /// </summary>
        public static string widgetAlreadyMemeber
        {
            get
            {
                return resourceProvider.GetResource("widgetAlreadyMemeber", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Subscribe.
        /// </summary>
        public static string widgetBtnSubscribe
        {
            get
            {
                return resourceProvider.GetResource("widgetBtnSubscribe", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Log in your account.
        /// </summary>
        public static string widgetMemberLogin
        {
            get
            {
                return resourceProvider.GetResource("widgetMemberLogin", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Our members always get priority care.
        /// </summary>
        public static string widgetMemberText
        {
            get
            {
                return resourceProvider.GetResource("widgetMemberText", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Do you get anything for sell ?.
        /// </summary>
        public static string widgetPostPromo
        {
            get
            {
                return resourceProvider.GetResource("widgetPostPromo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Sell your products online FOR FREE. It&apos;s easier than you think !.
        /// </summary>
        public static string widgetPostPromoContent
        {
            get
            {
                return resourceProvider.GetResource("widgetPostPromoContent", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Subscribe for updates.
        /// </summary>
        public static string widgetSubscribe
        {
            get
            {
                return resourceProvider.GetResource("widgetSubscribe", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        ///   Cerca una stringa localizzata simile a Join our 10,000+ subscribers and get access to the latest templates, freebies, announcements and resources!.
        /// </summary>
        public static string widgetSubscribeContent
        {
            get
            {
                return resourceProvider.GetResource("widgetSubscribeContent", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
    }
}