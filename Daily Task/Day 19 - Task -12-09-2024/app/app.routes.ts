import { Routes } from '@angular/router';
import { OrgListComponent } from './org-list/org-list.component';
import { OrgDetailsComponent } from './org-details/org-details.component';
import { AddOrganizationComponent } from './add-organization/add-organization.component';
import { DeleteOrgComponent } from './delete-org/delete-org.component';
import { UpdateOrgComponent } from './update-org/update-org.component';

export const routes: Routes = [
    {path:'',component:OrgListComponent},
    {path:'Organization/:id',component:OrgDetailsComponent},
    {path:'add',component:AddOrganizationComponent},
    {path:'delete/:id',component:DeleteOrgComponent},
    {path:'update/:id',component:UpdateOrgComponent}
];
