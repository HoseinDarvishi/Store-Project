const { parse } = require("path/posix");

function addToCart(id, name, picture, price) {
   let products = $.cookie("cart");

   if (products === undefined) {
      products = [];
   }
   else {
      products = JSON.parse(products);
   }

   let count = $("#productCount").val();
   let currentProduct = products.find(x => x.id === id);

   if (currentProduct !== undefined) {
      products.find(x => x.id === id).count = parseInt(currentProduct.count) + parseInt(count);
   }
   else {
      const product = {
         id,
         name,
         picture,
         price,
         count
      };

      products.push(product);
   }

   $.cookie("cart", JSON.stringify(products), { expires: 3, path: "/" });
   UpdateCart();
}

function UpdateCart() {
   let pros = $.cookie("cart");
   let products = JSON.parse(pros);
   $("#cart-count-buy-icon").text(products.length);

   $("#cart-item-header").html('');
   products.forEach(x => {
      const pro =`
         <div class="single-cart-item">
            <a href="javascript:void(0)" class="remove-icon" onclick="RemoveFromCart(${x.id})">
               <i class="ion-android-close"></i>
            </a>
            <div class="image">
               <a href="single-product.html">
                  <img width="100" src='ProductPictures/${x.picture}'>
               </a>
            </div>
            <div class="content">
               <p class="product-title">
                  <a href="single-product.html">${x.name}</a>
               </p>
               <p class="price">قیمت واحد : ${x.price}</p>
               <p class="cout">تعداد : ${x.count}</p>
            </div>
         </div>
      `;

      $("#cart-item-header").append(pro);
   })
}

function RemoveFromCart(id) {
   let pros = $.cookie("cart");
   let products = JSON.parse(pros);
   let product = products.findIndex(x => x.id === id);
   products.splice(product, 1);                                            // az products , product ra 1 bar hazf kon
   $.cookie("cart", JSON.stringify(products), { expires: 3, path: "/" });
   UpdateCart();
}

function ChangeCount(id, TotalId, count) {
   //Get Cookie
   var products = $.cookie("cart");
   products = JSON.parse(products);

   // Find Index of CHanged item
   var proIndex = products.findIndex(x => x.id == id);

   // Change its Count
   products[proIndex].count = parseInt(count);

   // Change Total price Element value
   var totalPrice = parseInt(count) * parseInt(products[proIndex].price);
   $(`#${TotalId}`).text(totalPrice);

   // Set New cookie
   $.cookie("cart", JSON.stringify(products), { expires: 2, path: "/" });
   UpdateCart();
}