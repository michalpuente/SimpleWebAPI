import {Routes} from '@angular/router';
import { ProductDetailsComponent } from './product/product-details/product-details.component';
import { ProductEditComponent } from './product/product-edit/product-edit.component';
import { ProductAddComponent } from './product/product-add/product-add.component';


export const appRoutes: Routes = [
    { path: '', component: ProductDetailsComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        children: [
            { path: 'getlist', component: ProductDetailsComponent},
            { path: 'getproductbyid/:id', component: ProductDetailsComponent},
            { path: 'updateproduct/:id', component: ProductEditComponent},
            { path: 'createproduct', component: ProductAddComponent} 
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full'}
];
