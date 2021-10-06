


$(document).ready(function() {

    forPlayerType();

    $('#player-type').on("change", function () {forPlayerType()});


    function forPlayerType() {



        var selected = $('#player-type').find(':selected').text();

        if (selected === "Member") {
            //Hide possiton field
            $("#player-position").hide();
            
            //Hide Player tabs
            $("#nav-Doctor-tab").hide();
            $("#nav-Kin-tab").hide();
            $("#nav-HealthIssues-tab").hide();
            $("#nav-Guardians-tab").hide();
            hideTab('#nav-Doctor');
            hideTab('#nav-Kin');
            hideTab('#nav-HealthIssues');
            hideTab('#nav-Guardians');
            
        } else if(selected === "Senior") {
            $("#player-position").show();
            $("#nav-Doctor-tab").show();
            $("#nav-Kin-tab").show();
            $("#nav-HealthIssues-tab").show();
            $("#nav-Guardians-tab").hide();
            showTab('#nav-Doctor');
            showTab('#nav-Kin');
            showTab('#nav-HealthIssues');
            hideTab('#nav-Guardians');
        }else if(selected === "Junior"){
            $("#player-position").show();
            $("#nav-Doctor-tab").show();
            $("#nav-Kin-tab").hide();
            $("#nav-HealthIssues-tab").show();
            $("#nav-Guardians-tab").show();
            showTab('#nav-Doctor');
            hideTab('#nav-Kin');
            showTab('#nav-HealthIssues');
            showTab('#nav-Guardians');
        }

       
    }
    
    function hideTab(panel){
        $(panel).find('*').addClass('ignore');
        $(panel).find('*').addClass('d-none');
    }

    function showTab(panel){
        $(panel).find('*').removeClass('ignore');
        $(panel).find('*').removeClass('d-none');
    }

    $("#memberForm").data("validator").settings.ignore = ".ignore";
    



    });


    
   