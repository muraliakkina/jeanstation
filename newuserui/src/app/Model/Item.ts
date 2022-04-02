export class Item {
    itemId:number;
    itemName:string;
    itemMaterial:string;
    itemBrandName:string;
    itemSize:string;
    itemPrice:number;
    itemStock:number;
    itemImage1:string;
    itemImage2:string;
    itemImage3:string;
    itemType:string;
    itemAdded:any;
    itemColor:string
    itemCategory:string;

    constructor(id:number,name:string,material:string,Bname:string,price:number,stock:number,size:string,type:string,img1:string,img2:string,img3:string,date:any,cat:string){
        this.itemBrandName = Bname;
        this.itemId =id;
        this.itemImage1 = img1;
        this.itemImage2 =img2;
        this.itemImage3 = img3;
        this.itemMaterial = material;
        this.itemPrice = price;
        this.itemSize = size;
        this.itemStock = stock;
        this.itemType = type;
        this.itemName = name;
        this.itemAdded = date;
        this.itemCategory = cat;
    }
}