import { RequestService } from './../services/request.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Request } from '../models/Request';

@Component({
  selector: 'app-requests',
  templateUrl: './requests.component.html',
  styleUrls: ['./requests.component.css']
})
export class RequestsComponent implements OnInit {

  public selectedRequest: Request = new Request();

  requestForm = new FormGroup({
    id: new FormControl(''),
    person: new FormControl(''),
    equipment: new FormControl(''),
    demand: new FormControl(''),
    serviceDescription: new FormControl(''),
    value: new FormControl('')
  });

  public requests: Request[] = [];

  constructor(private fb: FormBuilder,
              private requestService: RequestService) {
    this.createForm();
  }

  createForm() {
    this.requestForm = this.fb.group({
      id: [''],
      person: ['', Validators.required],
      equipment: ['', Validators.required],
      demand: ['', Validators.required],
      serviceDescription: [''],
      value: ['']
    })
  }

  ngOnInit(): void {
    this.loadRequests();
  }

  loadRequests() {
    this.requestService.getAll().subscribe(
      (result: Request[]) => {
        this.requests = result;
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

  selectRequest(request: Request) {
    this.selectedRequest = request;
    this.requestForm.patchValue(request);
  }

  newRequest() {
    this.selectedRequest = new Request();
    this.selectedRequest.id = -1;
    this.requestForm.patchValue(this.selectedRequest);
  }

  saveRequest(request: Request) {
    if (this.selectedRequest.id === -1) {
      request.id = 0;
      this.requestService.save(request).subscribe(
        (resultado: any) => {
          console.log(resultado);
          this.selectedRequest = resultado;
          this.loadRequests();
        },
        (erro: any) => {
          console.log(erro);
        }
      )
    } else {
      this.requestService.edit(request).subscribe(
        (result: any) => {
          console.log(result);
          this.selectedRequest = result;
          this.loadRequests();
        },
        (error: any) => {
          console.log(error);
        }
      )
    }
  }

  deleteRequest(request: Request) {
    this.requestService.delete(request.id).subscribe(
      (recurrence: any) => {
        console.log(recurrence);
        this.loadRequests();
      },
      (error: any) => {
        console.log(error);
      }
    )
  }

  onSubmit() {
    this.saveRequest(this.requestForm.value);
  }

  goBack() {
    this.selectedRequest = new Request();
  }

}
