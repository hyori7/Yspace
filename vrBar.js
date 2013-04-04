jQuery(function($){
	
	// Side Menu
	var sMenu = $('div.sMenu');
	var sItem = sMenu.find('>ul>li');
	var ssItem = sMenu.find('>ul>li>ul>li');
	var lastEvent = null;
	
	sItem.find('ul').attr('style','display:none');

	function sMenuToggle(event){
		var t = $(this);
		
		if (this == lastEvent) return false;
		lastEvent = this;
		setTimeout(function(){ lastEvent=null }, 200);
		
		if (t.next('ul').is(':hidden')) {
			sItem.find('>ul').slideUp(100);
			t.next('ul').slideDown(100);
		} else if(!t.next('ul').length) {
			sItem.find('>ul').slideUp(100);
		} else {
			t.next('ul').slideUp(100);
		}
		
		if (t.parent('li').hasClass('active')){
			sItem.removeClass('active');
		} else {
			sItem.removeClass('active');
			t.parent('li').addClass('active');
		}
	}
	sItem.find('>a').click(sMenuToggle).focus(sMenuToggle);
	
	function subMenuActive(){
		ssItem.removeClass('active');
		$(this).parent(ssItem).addClass('active');
	}; 
	
	ssItem.find('>a').click(subMenuActive).focus(subMenuActive);
	
	//icon
	sMenu.find('>ul>li>ul').prev('a').append('<span class="i"></span>');
});



