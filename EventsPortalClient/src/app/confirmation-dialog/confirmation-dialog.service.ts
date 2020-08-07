import { Injectable } from '@angular/core';

import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { ConfirmationDialogComponent } from './confirmation-dialog.component';

@Injectable()
export class ConfirmationDialogService {

  constructor(private modalService: NgbModal) { }

  public confirm(): Promise<boolean> {
    const modalRef = this.modalService.open(ConfirmationDialogComponent);
    return modalRef.result;
  }
}
