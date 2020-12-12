<template>
    <div id="sidebar">
        <b id="sidebar-title">{{title}}</b>
        <hr />
        <ul id="sidebar-list">
            <li><slot></slot></li>
        </ul>
        <!-- TODO(Jovan): Make component? -->
        <!-- <hr/>
        <div id="user-card">
            <div id="card-container">
                <div id="user-info">
                    <b id="username" class="user-field">{{user.username}}<span class="circle"></span></b>
                    <small id="usertype" class="user-field">
                        {{user.userType}}
                    </small>
                </div>
                <div id="user-controls">
                    <a @click="logout" href="#" class="user-field"><i class="fa fa-sign-out" aria-hidden="true"></i></a>
                </div>
            </div>
        </div> -->
    </div>
</template>

<script>
    module.exports = 
    {
        props: ["title", "user"],
        methods:
        {
            logout: function()
            {
                localStorage.removeItem("jwt");
                this.$router.go();
            }
        },
    }
</script>

<style>
    #sidebar
    {
        display: flex;
        flex-direction: column;
        justify-content: flex-start;
        height: 100%;
        z-index: 1;
        top: 0;
        left: 0;
        background-color: #3F51B5; /* #fff;*/
        overflow-x: hidden;
    }

    #sidebar-title
    {
        display: block;
        color: #fff;
        font-weight: 500;
        font-size: 1.5rem;
        text-align: center;
        padding: 8px 16px 8px 16px;
        font-family: "Poppins", sans-serif;
        font-weight: 400;
    }

    ul {
        margin: 0;
        padding: 0 !important;
        list-style-type: none;
    }

    #sidebar-list a
    {
        display: block;
        color: #fff;
        padding: 4px 8px 4px 8px;
        background-color: #3F51B5;
    }
    #sidebar-list a:hover
    {
        color: #fff;
        font-weight: 500;
        background-color: #ff5722;
    }

    #sidebar-list .router-link-exact-active
    {
        color: #fff;
        font-weight: 500;
        background-color: #ff5722;
        border-right: 2px solid #ff5722;
    }

    #user-card
    {
        width: 100%;
        background-color: rgb(250, 250, 250);
        border: 1px solid #e1e1e1;
        margin-top: auto;
    }

    #user-card a
    {
        color: #000;
    }

    #card-container
    {
        display: flex;
        flex-direction: row;
        justify-content: space-between;
        padding: 4px 8px 4px 8px;
    }

    #user-info
    {
        display: flex;
        flex-direction: column;
    }

    #user-controls
    {
        display: flex;
        align-items: center;
    }

    #user-controls a
    {
        font-size: 2rem;
    }

    #user-controls a:hover
    {
        color: #ff5722;
        background-color: #fafafa;
    }

    #usertype,
    #username
    {
        display: flex;
        flex-direction: row;
        justify-content: space-between;
        align-items: center;
        width: 100%;
    }

    .circle
    {
        display: inline-block;
        background-color: #0f0;
        width: 1rem;
        height: 1rem;
        border-radius: 50%;
    }

    #username
    {
        font-weight: 500;
    }
    
    hr
    {
        width: 70%;
        margin: 0 auto;
    }
</style>
