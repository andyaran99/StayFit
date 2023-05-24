
function Payment(){
    return(
    <html lang="en" data-theme="dark">
    <head>
        <title>Payment</title>
        <script src="./lib/checkoutHelper"></script>
        
    </head>
    <body>
    <div className="container">
        <div className="row">
            <div className="col-sm"></div>
            <div className="col-sm">
                <h2 className="ms-text-center">ai-generated NFT Bored Ape</h2>
                <div className="ms-text-center pb-2">
                    <div className="ms-label ms-large ms-action2 ms-light">$100.00 USD</div>
                </div>
                <div id="alerts" className="ms-text-center"></div>
                <div id="loading" className="spinner-container ms-div-center">
                    <div className="spinner"></div>
                </div>
                <div id="content" className="hide">
                    <div className="ms-card ms-fill">
                        <div className="ms-card-content">
                            
                        </div>
                    </div>
                    <div id="payment_options"></div>
                </div>
            </div>
            <div className="col-sm"></div>
        </div>
    </div>
    </body>
</html>
);
}

export default Payment;