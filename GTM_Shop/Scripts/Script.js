$(document).ready(function(){




	/* Mouse over du menu footer */
	$('.Ligne_menu_footer').hover(function(){
	    $(this).css('text-decoration', 'underline');
	    $(this).css('color', 'white');
	},function(){
		$(this).css('text-decoration','none');
	});

	/* Mouse over du menu */
	$('.Lien_menu').hover(function(){
	    $(this).css('color', '#FF9900');
        $(this).css('text-decoration','none');
	},function(){
		$(this).css('color','white');
	});
	
	/* Mouse over des icones menu */
	$('#Icone_Recherche').hover(function(){
	    $(this).attr('src', '/Content/images/Icone_Recherche_On.png');
	},function(){
	    $(this).attr('src', '/Content/images/Icone_Recherche.png');
	});
	
	$('#Icone_Mail').hover(function(){
	    $(this).attr('src', '/Content/images/Icone_Mail_On.png');
	},function(){
	    $(this).attr('src', '/Content/images/Icone_Mail.png');
	});
	
	$('#Icone_Connexion').hover(function(){
	    $(this).attr('src', '/Content/images/Icone_connexion_On.png');
	},function(){
	    $(this).attr('src', '/Content/images/Icone_connexion.png');
	});

	$('#Icone_Deconnexion').hover(function () {
	    $(this).attr('src', '/Content/images/Icone_deconnexion_On.png');
	}, function () {
	    $(this).attr('src', '/Content/images/Icone_deconnexion.png');
	});
	
	$('#Icone_Add_Profil').hover(function(){
	    $(this).attr('src', '/Content/images/Icone_Add_Profil_On.png');
	},function(){
	    $(this).attr('src', '/Content/images/Icone_Add_Profil.png');
	});
	
	$('#Icone_Panier').hover(function(){
	    $(this).attr('src', '/Content/images/Icone_Panier_On.png');
	},function(){
	    $(this).attr('src', '/Content/images/Icone_Panier.png');
	});



    /* Mouse hover pour les zoom image A FAIRE !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! */  
	//$('.Img_produit').hover(function () {
	//    $(this).css('height', '150px');},
	//    function(){
	//        $(this).attr('src', '/Content/images/Icone_Panier.png');
	//});




});