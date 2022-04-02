export interface Product {
    itemId: number;
    itemName: string;
    description: string;
    material: string;
    type: string;
    category: string;
    dateAdded:string;
    size:string;
    quantity:number;
    color:string;
    brandName:string;
    imageurl1:string;
    imageurl2:string;
    imageurl3:string;

    // constructor(id:number,name:string,material:string,type:string,cat:string,date:string,size:string,quantity:string){
    //     this.itemId = id;
    //     this.category =cat;
    //     this.dateAdded =date;
    //     this.material =material;
    //     this.name = name;
    //     this.type = type;
    //     this.size = size;
    //     this.quantity = quantity;
    // }
}
